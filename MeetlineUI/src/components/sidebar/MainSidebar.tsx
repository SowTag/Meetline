import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
} from '#/components/ui/sidebar.tsx'
import type { ComponentProps } from 'react'
import { NavUser, type SidebarUser } from '#/components/sidebar/NavUser.tsx'

type MainSidebarProps = ComponentProps<typeof Sidebar> & {
  user: SidebarUser | null
}

export function MainSidebar({ user, ...props }: MainSidebarProps) {
  return (
    <Sidebar collapsible={'icon'} {...props}>
      <SidebarHeader></SidebarHeader>
      <SidebarContent></SidebarContent>
      <SidebarFooter>
        <NavUser user={user} />
      </SidebarFooter>
    </Sidebar>
  )
}
