import { createFileRoute } from '@tanstack/react-router'
import { UserProfile } from '@clerk/react'

export const Route = createFileRoute(
  '/_authenticated/_sidebar/account-settings/$',
)({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <main className={'h-full flex items-center justify-center'}>
      <UserProfile />
    </main>
  )
}
