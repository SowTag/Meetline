import { SidebarTrigger } from '#/components/ui/sidebar.tsx'
import { useIsMobile } from '#/hooks/use-mobile.ts'

export function MainHeader() {
  const isMobile = useIsMobile()

  return (
    <header
      className={'h-12 shrink-0 border-b flex items-center px-4 bg-sidebar'}
    >
      {isMobile && <SidebarTrigger className={'mr-4'} />}
      <span>This is a cool header.</span>
    </header>
  )
}
